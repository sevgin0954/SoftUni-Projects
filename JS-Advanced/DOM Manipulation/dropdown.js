function addItem() {
    let text = document.getElementById('newItemText')
    let value = document.getElementById('newItemValue')
    let result = text.value + value.value

    text.value = ''
    value.value = ''

    let element = document.createElement('option')
    element.textContent = result

    let dropdown = document.getElementById('menu')

    dropdown.appendChild(element)
}