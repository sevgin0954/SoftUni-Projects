function theHungryProgrammer(meals, commands) {
    let index = 0;
    let mealsEatenCount = 0;

    let actions = {
        Serve: () => {
            if (meals.length !== 0) {
                console.log(`${meals.pop()} served!`)
            }
        },
        Add: (meal) => {
            if (meal.length !== 0) {
                meals.unshift(meal);
            }
        },
        Shift: (args) => {
            if (meals.length !== 0) {
                let index1 = Number(args[0]);
                let index2 = Number(args[1]);

                if (index1 >= 0 && index2 < meals.length) {
                    let meal1 = meals[index1];
                    meals[index1] = meals[index2];
                    meals[index2] = meal1;
                }
            }
        },
        Eat: () => {
            if (meals.length !== 0) {
                console.log(`${meals[0]} eaten`);
                meals.shift();
                mealsEatenCount++;
            }
        },
        Consume: (args) => {
            if (meals.length !== 0) {
                let startIndex = Number(args[0]);
                let endIndex = Number(args[1]);

                if (startIndex >= 0 && endIndex < meals.length) {
                    let count = endIndex - startIndex + 1;

                    meals.splice(startIndex, count);
                    mealsEatenCount += count;

                    console.log('Burp!');
                }
            }
        }
    };

    for (let a = 0; a < commands.length; a++) {
        let args = commands[a].split(' ');
        let command = args[0];
        args.shift();

        if (command === 'End') {
            let mealsLeft;

            if (meals.length === 0) {
                mealsLeft = 'The food is gone';
            }
            else {
                mealsLeft = 'Meals left: ' + meals.join(', ');
            }

            console.log(mealsLeft);
            console.log(`Meals eaten: ${mealsEatenCount}`);
            return;
        }
        if (actions[command]) {
            actions[command](args);
        }
    }
}