using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Rust.Option
{
    /// <summary>
    /// Обертка для возвращаемых значений функций. 
    /// Создан для улучшения стабильности кода.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct Option<T>
    {

        #region Fields

        /// <summary>
        /// Значение
        /// </summary>
        private T value;
        /// <summary>
        /// Ошибка
        /// </summary>
        private Exception ex;

        #endregion

        #region Constructors

        /// <summary>
        /// Выполняеь переданную в конструктор функцию
        /// </summary>
        /// <param name="func"></param>
        public Option(Func<T> func)
        {
            if (func == null)
            {
                value = default;
                ex = new Exception($"'{nameof(func)}' can't be null");
                return;
            }
            try
            {
                value = func.Invoke();
                ex = null;
            }
            catch (Exception e)
            {
                value = default;
                ex = e;
            }
        }
        /// <summary>
        /// Создает структуру на основе переданных в нее параметров
        /// </summary>
        /// <param name="value"></param>
        /// <param name="ex"></param>
        private Option(T value, Exception ex)
        {
            this.value = value;
            this.ex = ex;
        }

        #endregion

        #region Methods

        #region Public

        /// <summary>
        /// Возвращает значение вне зависимости от наличия ошибок
        /// </summary>
        /// <returns>Значение</returns>
        [Obsolete("Use 'Match' method instead", false)]
        public T Unwrap() => value;
        /// <summary>
        /// Стандартный обработчик. Если ошибки нет то вызовет аргумент
        /// Some, иначе будет вызван None. 
        /// </summary>
        /// <param name="Some">Функция будет вызвана, если структура не содержит ошибки</param>
        /// <param name="None">Действие будет вызвано, если структура содержит ошибку</param>
        /// <returns>Возвращает результат выполнения одной из функций</returns>
        public T Match(Func<T, T> Some, Func<Exception, T> None)
        {
            if (ex != null && None != null)
                return None.Invoke(ex);
            else if (Some != null)
                return Some.Invoke(value);
            return default(T);
        }
        /// <summary>
        /// Стандартный обработчик. Если ошибки нет то вызовет аргумент
        /// Some, иначе будет вызван None. 
        /// </summary>
        /// <param name="Some">Функция будет вызвана, если структура не содержит ошибки</param>
        /// <param name="None">Действие будет вызвано, если структура содержит ошибку</param>
        public void Match(Action<T> Some, Action<Exception> None)
        {
            if (ex != null && None != null)
                None.Invoke(ex);
            else if (Some != null)
                Some.Invoke(value);
        }

        /// <summary>
        /// Стандартный обработчик. Если ошибки нет то вызовет аргумент
        /// Some, иначе будет вызван None. Данная функция возвращает 
        /// новое знаечние на основе текущего состояния структуры.
        /// </summary>
        /// <typeparam name="T1">Тип нового возвращаемого значения</typeparam>
        /// <param name="Some">Функция будет вызвана, если структура не содержит ошибки</param>
        /// <param name="None">Действие будет вызвано, если структура содержит ошибку</param>
        /// <returns>Новое значение</returns>
        public T1 Select<T1>(Func<T, T1> Some, Func<Exception, T1> None)
        {
            if (ex != null && None != null)
                return None.Invoke(ex);
            else if (Some != null)
                return Some.Invoke(value);
            return default(T1);
        }

        /// <summary>
        /// Определяет состояние стурктуры, вернет true если она не содержит ошибки,
        /// в любом другом случае вернет false
        /// </summary>
        public bool IsNone => ex != null;
        /// <summary>
        /// Вернет true если структура не содержит ошибки и переданная функция вернет true, 
        /// в любом другом случае вернет false
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public bool IsSomeAnd(Func<T, bool> action) => ex != null && (action?.Invoke(value) ?? false);

        #endregion

        #region Static

        /// <summary>
        /// Создает стурктуру со значением
        /// </summary>
        /// <param name="value">Значение</param>
        /// <returns>Структура со значением</returns>
        public static Option<T> Some(T value) => new Option<T>(value, default);
        /// <summary>
        /// Создает стурктуру с ошибкой
        /// </summary>
        /// <param name="ex">Ошибка</param>
        /// <returns>Структура с ошибкой</returns>
        public static Option<T> None(Exception ex) => new Option<T>(default, ex);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Option<T> None() => new Option<T>(default, new NotImplementedException());

        #endregion

        #endregion
    }
}