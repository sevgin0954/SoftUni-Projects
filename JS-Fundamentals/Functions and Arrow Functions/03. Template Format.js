function formatAsXML(questionsAnswers) {
    console.log('<?xml version="1.0" encoding="UTF-8"?>');
    console.log('<quiz>');

    for (let a = 0; a < questionsAnswers.length - 1; a+=2) {
        let question = questionsAnswers[a];
        let answer = questionsAnswers[a + 1];

        printAsXML(question, answer);
    }

    console.log('</quiz>');

    function printAsXML(question, answer) {
        console.log('  <question>');
        console.log('    ' + question);
        console.log('  </question>');

        console.log('  <answer>');
        console.log('    ' + answer);
        console.log('  </answer>');
    }
}