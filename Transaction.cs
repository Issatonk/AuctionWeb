using System;

namespace Auction.DAL.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public enum TransactionType
    {
        Deposit,
        Withdrawal
    }
}