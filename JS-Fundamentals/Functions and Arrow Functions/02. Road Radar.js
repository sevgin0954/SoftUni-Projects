function checkSpeed(speedArea) {
    let output = '';
    let speedLimit = 0;

    switch (speedArea[1]) {
        case 'motorway':
            speedLimit = 130;
            break;
        case 'interstate':
            speedLimit = 90;
            break;
        case 'city':
            speedLimit = 50;
            break;
        case 'residential':
            speedLimit = 20;
            break;
    }

    let speedDiference = speedArea[0] - speedLimit;

    if (speedDiference <= 20 && speedDiference > 0) {
        output = 'speeding';
    }
    else if (speedDiference <= 40 && speedDiference > 0) {
        output = 'excessive speeding';
    }
    else if (speedDiference > 40 && speedDiference > 0) {
        output = 'reckless driving';
    }

    return output;
}