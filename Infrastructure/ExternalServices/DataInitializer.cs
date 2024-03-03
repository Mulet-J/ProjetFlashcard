using Domain.Entities;
using Domain.Enums;
using System.Globalization;

namespace Infrastructure.ExternalServices
{
    public static class DataInitializer
    {
        public static List<Card> GetInitialData() =>
            [
                new()
                {
                    Id = "b950c18c-6721-4c00-bd12-e498b037551d",
                    LastAnswerDate = DateOnly.Parse("2024-02-18", CultureInfo.InvariantCulture),
                    CardUserData = new()
                    {
                        Id = "237ab7d3-0586-42f3-95de-8c42704bc89e",
                        Answer = "Paris",
                        Question = "What is the capital of France?",
                        Tag = "geography",
                    },
                    Category = Category.FIRST
                },
                new()
                {
                    Id = "92d2c667-36d8-4943-9d6e-d28af92ccbf8",
                    LastAnswerDate = DateOnly.Parse("2024-02-18", CultureInfo.InvariantCulture),
                    CardUserData = new()
                    {
                        Id = "35619a7a-8ad9-4f7e-b894-93eb3b2b8c26",
                        Answer = "Beethoven",
                        Question = "Who composed Symphony No. 9 in D minor, Op. 125, also known as the Choral Symphony?",
                        Tag = "music",
                    },
                    Category = Category.SECOND
                },
                new()
                {
                    Id = "ab821e3d-9a5e-4b29-a09c-6f2c2e6894fa",
                    LastAnswerDate = DateOnly.Parse("2024-02-18", CultureInfo.InvariantCulture),
                    CardUserData = new()
                    {
                        Id = "8a3f52d7-16c1-4a09-927a-961a4f25689f",
                        Answer = "Tokyo",
                        Question = "What is the capital of Japan?",
                        Tag = "geography",
                    },
                    Category = Category.THIRD
                },
                new()
                {
                    Id = "c5e20b8f-4e41-43d5-af80-14d49de663fd",
                    LastAnswerDate = DateOnly.Parse("2024-02-18", CultureInfo.InvariantCulture),
                    CardUserData = new()
                    {
                        Id = "9e2b1f6d-1dcf-47d4-8d9c-944ce0361a05",
                        Answer = "Mount Everest",
                        Question = "What is the highest mountain on Earth?",
                        Tag = "geography",
                    },
                    Category = Category.FOURTH
                },
                new()
                {
                    Id = "f6e7399d-0413-4da3-b1b7-981e2959e586",
                    LastAnswerDate = DateOnly.Parse("2024-02-18", CultureInfo.InvariantCulture),
                    CardUserData = new()
                    {
                        Id = "5a9d10d1-291f-42ab-b8e8-02d5829c7f1f",
                        Answer = "Albert Einstein",
                        Question = "Who developed the theory of relativity?",
                        Tag = "science",
                    },
                    Category = Category.FIFTH
                },
                new()
                {
                    Id = "cf9d8f8c-4f92-4918-9ff3-b7910b4a7091",
                    LastAnswerDate = DateOnly.Parse("2024-02-18", CultureInfo.InvariantCulture),
                    CardUserData = new()
                    {
                        Id = "91f1e86b-c20e-40e1-846f-2ad537f6aa4a",
                        Answer = "Python",
                        Question = "What is a popular programming language for data science?",
                        Tag = "technology",
                    },
                    Category = Category.SIXTH
                },
                new()
                {
                    Id = "7fd2e118-d881-4d25-894e-0f4efbd1e6bc",
                    LastAnswerDate = DateOnly.Parse("2024-02-18", CultureInfo.InvariantCulture),
                    CardUserData = new()
                    {
                        Id = "a5184a26-f036-4e4e-9f46-18a3c7a19fa0",
                        Answer = "Mount Everest",
                        Question = "What is the highest mountain in the world?",
                        Tag = "geography",
                    },
                    Category = Category.SEVENTH
                },
                new()
                {
                    Id = "e2fb2b0d-9d7e-4b56-ae54-3a5f3c54e1ee",
                    LastAnswerDate = DateOnly.Parse("2024-02-18", CultureInfo.InvariantCulture),
                    CardUserData = new()
                    {
                        Id = "c91e85cf-1f11-4d4e-9f25-046d3a0d63a7",
                        Answer = "42",
                        Question = "What is the answer to the ultimate question of life, the universe, and everything?",
                        Tag = "philosophy",
                    },
                    Category = Category.DONE
                },
            ];
    }
}
