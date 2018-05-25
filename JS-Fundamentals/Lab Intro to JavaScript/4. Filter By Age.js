function filterPersonsByAge(minimumAge, person1Name, person1Age, person2Name, person2Age) {
    if (person1Age >= minimumAge) {
        console.log(`{ name: '${person1Name}', age: ${person1Age} }`)
    }
    if (person2Age >= minimumAge) {
        console.log(`{ name: '${person2Name}', age: ${person2Age} }`)
    }
}