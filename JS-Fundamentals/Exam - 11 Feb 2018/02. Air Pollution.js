function trackpollutionInTheAir(mapMatrix, forces) {
    let map = [];

    for (let a = 0; a < mapMatrix.length; a++) {
        map[a] = mapMatrix[a].split(' ').map(Number);
    }

    let actions = {
        breeze: (index) => {
            for (let col = 0; col < map[0].length; col++) {
                map[index][col] = Math.max(0, map[index][col] - 15);
            }
        },
        gale: (index) => {
            for (let row = 0; row < map.length; row++) {
                map[row][index] = Math.max(0, map[row][index] - 20);
            }
        },
        smog: (value) => {
            for (let row = 0; row < map.length; row++) {
                for (let col = 0; col < map[0].length; col++) {
                    map[row][col] += value;
                }
            }
        }
    };

    for (let a = 0; a < forces.length; a++) {
        let forceArgs = forces[a].split(' ');
        let forceName = forceArgs[0];
        let value = Number(forceArgs[1]);

        actions[forceName](value);
    }

    let polutetAreas = [];

    for (let row = 0; row < map.length; row++) {
        for (let col = 0; col < map[0].length; col++) {
            if (map[row][col] >= 50) {
                polutetAreas.push(`[${row}-${col}]`);
            }
        }
    }

    if (polutetAreas.length > 0) {
        console.log('Polluted areas: ' + polutetAreas.join(', '));
    }
    else {
        console.log('No polluted areas');
    }
}