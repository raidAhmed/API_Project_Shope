using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.News
{
    public class NewsDto
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? DeleteAt { get; set; }
        public int? MarketsId { get; set; }
        public int? ProductId { get; set; }
        public int? State { get; set; }
        public IFormFile? File { get; set; }
    }
}
