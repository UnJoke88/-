using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 
/// </summary>
public enum TransactionType
{
    Deposit = 0,     // Пополнение счёта
    Withdrawal = 1,  // Снятие средств
    Buy = 2,         // Покупка актива
    Sell = 3,        // Продажа актива
    Fee = 4          // Комиссия брокера
}

