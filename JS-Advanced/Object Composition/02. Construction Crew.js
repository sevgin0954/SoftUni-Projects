function constructionCrew(worker) {
    if (worker.handsShaking === true) {
        let alcoholIntakeRequired = worker.weight * worker.experience * 0.1
        worker.handsShaking = false
        worker.bloodAlcoholLevel += alcoholIntakeRequired
    }

    return worker
}