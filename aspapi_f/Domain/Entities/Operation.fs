open System

type Operation =
    { categoryId: Guid
      cashId: Guid
      date: DateTime
      description: string
      value: int }
