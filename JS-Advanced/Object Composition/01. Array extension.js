(function arrayExtend() {
    Array.prototype.last = function () {
        return this[this.length - 1]
    }

    Array.prototype.skip = function (n) {
        let newArr = []

        for (let a = n; a < this.length; a++) {
            newArr.push(this[a])
        }

        return newArr
    }

    Array.prototype.take = function (index) {
        let newArr = []

        for (let a = 0; a <= index; a++) {
            newArr.push(this[a])
        }

        return newArr
    }

    Array.prototype.sum = function () {
        let sum = 0

        for (let a = 0; a < this.length; a++) {
            sum += this[a]
        }

        return sum
    }
    
    Array.prototype.average = function () {
        return this.sum() / this.length
    }
})()