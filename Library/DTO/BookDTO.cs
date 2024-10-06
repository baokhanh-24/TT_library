﻿using System.ComponentModel.DataAnnotations;

namespace Library.DTO
{
    public class BookDTO
    {
        public int books_ID { get; set; }
        public string title { get; set; }
        public string image { get; set; }
        public string subtitle { get; set; }
        public int authors_ID { get; set; }
        public int genres_ID { get; set; }
        public int publishing_Year { get; set; }
        public int quantity_In_Stock { get; set; }
        public string description { get; set; }
        public DateTime create_At { get; set; }
        public DateTime update_At { get; set; }
        public bool delete_Flag { get; set; }
    }
}
