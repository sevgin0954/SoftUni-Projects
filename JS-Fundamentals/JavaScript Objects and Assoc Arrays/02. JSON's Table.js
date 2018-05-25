function employeesToHtml(input) {
    let employees = parseEmployees(input);
    print(employees);


    function parseEmployees(employees) {
        let output = [];

        for (let key in employees) {
            output.push(JSON.parse(employees[key]));
        }

        return output;
    }

    function print() {
        console.log('<table>');
        for (let key in employees) {
            console.log('   <tr>');
            printEmployee(employees[key]);
            console.log('   <tr>');
        }
        console.log('</table>');

        function printEmployee(employee) {
            for (let key in employee) {
                console.log('       <td>' + employee[key] + '</td>');
            }
        }
    }
}