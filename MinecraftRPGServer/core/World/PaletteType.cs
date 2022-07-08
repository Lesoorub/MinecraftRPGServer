public enum PaletteType : byte
{
    /// <summary>
    /// Pallete.length == 1 && data == null. Весь сектор заполнен одним блоком
    /// </summary>
    Single, 
    /// <summary>
    /// Pallete.length > 1 && data != null. В data индексы на элементы в палитре.
    /// </summary>
    Indirect, 
    /// <summary>
    /// Pallete == null && data != null. В данных ссылки на глобальную палитру
    /// </summary>
    Direct
}
