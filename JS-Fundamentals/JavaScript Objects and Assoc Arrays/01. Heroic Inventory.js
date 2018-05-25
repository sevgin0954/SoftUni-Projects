function printHeroesAsJSON(input) {
    let heroes = [];

    for (let a = 0; a < input.length; a++) {
        let currentHeroInfos = input[a].split(/\s*\/\s*/g).filter(str => str !== '');
        let heroItems = [];
        if (currentHeroInfos.length > 2) {
            heroItems = currentHeroInfos[2].split(/\s*,\s*/g).filter(str => str !== '');
        }

        let name = currentHeroInfos[0];
        let level = Number(currentHeroInfos[1]);

        let hero = {
            name: name,
            level: level,
            items: heroItems
        };

        heroes.push(hero);
    }

    console.log(JSON.stringify(heroes))
}