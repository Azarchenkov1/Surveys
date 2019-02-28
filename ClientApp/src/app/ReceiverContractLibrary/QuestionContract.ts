interface QuestionContract {
    Id: number,
    questionDescription: string
    additionalInformation: string

    answerList: AnswerContract[]
}