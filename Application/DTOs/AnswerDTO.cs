using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjetFlashcard.Application.DTOs
{
    public class AnswerDTO
    {
        //[JsonPropertyName("isValid")]
        public bool IsValid { get; set; }

        public AnswerDTO(bool isValid)
        {
            IsValid = isValid;
        }

        public AnswerDTO() { }
    }
}
