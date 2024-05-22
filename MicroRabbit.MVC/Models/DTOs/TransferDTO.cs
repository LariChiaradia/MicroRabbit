namespace MicroRabbit.MVC.Models.DTOs
{
    public record TransferDTO
    {
        public int FromAccount { get; set; }
        public int ToAccount { get; set; }
        public decimal TransferAmount { get; set; }
    }
}
