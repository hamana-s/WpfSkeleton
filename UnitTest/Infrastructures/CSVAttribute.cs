using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Xunit.Sdk;

namespace UnitTest.Infrastructures
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class CSVAttribute : DataAttribute
    {
        private readonly string _fileName;

        /// <summary>
        /// パラメーター変換
        /// </summary>
        /// <param name="parameter">値</param>
        /// <param name="parameterType">型</param>
        /// <returns>オブジェクト</returns>
        private static object ConvertParameter(object parameter, Type parameterType)
        {
            return parameterType == typeof(int) ? Convert.ToInt32(parameter) : parameter;
        }

        /// <summary>
        /// パラメーター変換
        /// </summary>
        /// <param name="values">パラメータの値</param>
        /// <param name="parameterTypes">型</param>
        /// <returns>配列</returns>
        private static object[] ConvertParameters(IReadOnlyList<object> values, IReadOnlyList<Type> parameterTypes)
        {
            var result = new object[parameterTypes.Count];
            for (var idx = 0; idx < parameterTypes.Count; idx++)
            {
                result[idx] = ConvertParameter(values[idx], parameterTypes[idx]);
            }
            return result;
        }

        /// <summary>
        /// データ取得
        /// </summary>
        /// <param name="testMethod">メソッド情報？</param>
        /// <returns>データ配列</returns>
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            string line;

            var pars = testMethod.GetParameters();
            var parameterTypes = pars.Select(par => par.ParameterType).ToArray();

            using var csvFile = new StreamReader(_fileName);

            // ヘッダ行読み飛ばし
            csvFile.ReadLine();

            while ((line = csvFile.ReadLine()) != null)
            {
                var row = line.Split(',');
                yield return ConvertParameters(row, parameterTypes);
            }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        public CSVAttribute(string fileName)
        {
            _fileName = fileName;
        }
    }
}
