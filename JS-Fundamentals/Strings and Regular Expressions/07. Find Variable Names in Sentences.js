function findAllVariableNames(string) {
    let variables = [];
    let regx = /_(\w+)/g;

    while (true) {
        let variable = regx.exec(string);
        if (variable === null) {
            break;
        }

        variables.push(variable[1]);
    }

    console.log(variables.join(','));
}