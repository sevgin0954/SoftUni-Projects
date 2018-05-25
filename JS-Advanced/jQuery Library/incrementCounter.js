function increment(selector) {
    let target = $(selector)[0]

    let textarea = $('<textarea>')[0]
    textarea.className = 'counter'
    textarea.value = 0
    $(textarea).attr('disabled', true)

    let button1 = $('<button>')[0]
    button1.className = 'btn'
    button1.id = 'incrementBtn'
    button1.textContent = 'Increment'
    $(button1).on('click', function () {
        textarea.value++
    })

    let ul = $('<ul>')[0]
    ul.className = 'results'

    let button2 = $('<button>')[0]
    button2.className = 'btn'
    button2.id = 'addBtn'
    button2.textContent = 'Add'
    $(button2).on('click', function () {
        let li = $('<li>')[0]
        li.textContent = textarea.value
        ul.append(li)
    })

    $(target).append(textarea)
    $(target).append(button1)
    $(target).append(button2)
    $(target).append(ul)
}