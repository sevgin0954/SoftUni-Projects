function createBook(selector, title, author, isbn) {
    let target = $(selector)[0]
    let div = $('<div>')[0]

    div.id = 'book'
    div.style.border = 'medium none'

    let titleP = $('<p>')[0]
    titleP.className = 'title'
    titleP.textContent = title

    let authorP = $('<p>')[0]
    authorP.className = 'author'
    authorP.textContent = author

    let isbnP = $('<isbn>')[0]
    isbnP.className = 'isbn'
    isbnP.textContent = isbn

    let selectButton = $('<button>')[0]
    selectButton.textContent = 'Select'
    $(selectButton).on('click', function () {
        div.style.border = '2px solid blue'
    })

    let deselectButton = $('<button>')[0]
    deselectButton.textContent = 'Deselect'
    $(deselectButton).on('click', function () {
        div.style.border = 'none'
    })

    div.appendChild(titleP)
    div.appendChild(authorP)
    div.appendChild(isbnP)
    div.appendChild(selectButton)
    div.appendChild(deselectButton)

    target.appendChild(div)
}
