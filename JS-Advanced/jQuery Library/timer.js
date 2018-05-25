function timer() {
    let startBtn = $('#start-timer')[0]
    let stopBtn = $('#stop-timer')[0]

    let isStartTimerRunning = false

    $(startBtn).on('click', startTimer)

    function startTimer() {
        if (isStartTimerRunning) {
            return
        }

        $(stopBtn).on('click', stopTimer)
        let timeout = setInterval(runTimer, 1000)
        isStartTimerRunning = true

        function runTimer() {
            let seconds = $('#seconds')[0]

            if (Number(seconds.textContent) == 59) {
                seconds.textContent = '00'
                let minutes = $('#minutes')[0]

                if (Number(minutes.textContent) == 59) {
                    minutes.textContent = '00'
                    let hours = $('#hours')[0]
                    let currentHours = Number(hours.textContent) + 1

                    if (currentHours < 10) {
                        currentHours = '0' + currentHours
                    }

                    hours.textContent = currentHours
                }
                else {
                    let currentMins = Number(minutes.textContent) + 1

                    if (currentMins < 10) {
                        currentMins = '0' + currentMins
                    }

                    minutes.textContent = currentMins
                }
            }
            else {
                let currentSecond = Number(seconds.textContent) + 1

                if (currentSecond < 10) {
                    currentSecond = '0' + currentSecond
                }

                seconds.textContent = currentSecond
            }
        }

        function stopTimer() {
            clearInterval(timeout)
            isStartTimerRunning = false
        }
    }
}