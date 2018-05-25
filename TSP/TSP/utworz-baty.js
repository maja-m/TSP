const fs = require("fs");
const path = require("path");

const dane = [
  [10, 5, 50, 0.5],
  [50, 5, 50, 0.5],
  [100, 5, 50, 0.5],
  [500, 5, 50, 0.5],
  [100, 10, 50, 0.5],
  [100, 5, 85, 0.5],
  [100, 5, 50, 0.5],
  [100, 5, 22, 0.5],
  [100, 5, 50, 0.1],
  [100, 5, 50, 0.8],
  [100, 5, 40, 0.5],
  [100, 5, 30, 0.5]
];

const pliki = ["gr9882", "sw24978"];
const krzyzowania = ["OX", "przezWymianePodtras"];
const selekcje = ["turniejowa", "ruletkaWartosciowa"];

const baterie = {
  gr9882: [85, 50, 30, 22, 20],
  sw24978: [85, 50, 40, 22]
};

const dane2 = dane.map(d => ({ populacja: d[0], pokolenia: d[1], baterie: d[2], mutacja: d[3] }));

const dane3 = pliki.reduce((acc, plik) => {
  return acc.concat(dane2.map(d => ({ ...d, plik })));
}, []);

const dane4 = krzyzowania.reduce((acc, operator) => {
  return acc.concat(dane3.map(d => ({ ...d, operator })));
}, []);

const dane5 = selekcje.reduce((acc, selekcja) => {
  return acc.concat(dane4.map(d => ({ ...d, selekcja })));
}, []);

const nazwaPliku = d =>
  `${d.plik}-${d.populacja}-${d.pokolenia}-${d.operator}-${d.baterie}-${d.selekcja}-${d.mutacja}.bat`;
const nazwaPlikuZach = d => `zachlanny-${d.plik}-${d.baterie}.bat`;

const wzor = d => ({
  ...d,
  tresc:
    `rem TSP.exe nazwaPlikuWejsciowego wielkoscPopulacji liczbaPokolen krzyzowanie liczbaBaterii selekcja prawdopodobienstwoMutacji\n` +
    `.\\TSP.exe ${d.plik} ${d.populacja} ${d.pokolenia} ${d.operator} ${d.baterie} ${d.selekcja} ${d.mutacja}`,
  xml: `<None Include="Bat\\${nazwaPliku(d)}">
    <CopyToOutputDirectory>Always</CopyToOutputDirectory>
  </None>`,
  sciezka: nazwaPliku(d)
});

const wzorZach = d => ({
  ...d,
  tresc: `rem TSP.exe nazwaPlikuWejsciowego liczbaBaterii\n` + `.\\TSP.exe ${d.plik} ${d.baterie}`,
  xml: `<None Include="Bat\\${nazwaPlikuZach(d)}">
  <CopyToOutputDirectory>Always</CopyToOutputDirectory>
</None>`,
  sciezka: nazwaPlikuZach(d)
});
const tresciZach = pliki
  .reduce((acc, plik) => {
    return acc.concat(baterie[plik].map(d => ({ plik, baterie: d })));
  }, [])
  .map(wzorZach);

const tresci = dane5.map(wzor);

const wszystkieTresci = [...tresci, ...tresciZach];

if (!fs.existsSync("baty")) {
  fs.mkdirSync("baty");
}

wszystkieTresci.forEach(d => {
  fs.writeFileSync(path.join("baty", d.sciezka), d.tresc, { encoding: "utf8" });
});

const xmle = wszystkieTresci.map(d => d.xml).join("\n");
fs.writeFileSync(path.join("baty", "ccsproj.txt"), xmle, { encoding: "utf8" });
