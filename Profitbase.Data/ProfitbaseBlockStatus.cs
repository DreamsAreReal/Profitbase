namespace Profitbase.Data
{
    /// <summary>
    /// Статус помещения
    /// </summary>
    public enum ProfitbaseBlockStatus
    {
        /// <summary>
        /// Забронировано
        /// </summary>
        Blocked,
        /// <summary>
        /// Продано
        /// </summary>
        Sealed,
        /// <summary>
        /// В продаже
        /// </summary>
        InStock,
        /// <summary>
        /// Недоступно
        /// </summary>
        Empty
    }
}