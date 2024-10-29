using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;

namespace DaVinci.Service
{
    public class MLService
    {
        private readonly InferenceSession _session;

        public MLService()
        {
            _session = new InferenceSession("MLModel/modelo_analise_sentimento.onnx");
        }

        public string PredizerSentimento(string entrada)
        {
            var tensor = new DenseTensor<string>(new[] { entrada }, new[] { 1, 1 });
            var input = new NamedOnnxValue[] { NamedOnnxValue.CreateFromTensor("input", tensor) };
            using var resultados = _session.Run(input);
            var resultado = resultados.First().AsTensor<string>().First();
            return resultado;
        }
    }
}
