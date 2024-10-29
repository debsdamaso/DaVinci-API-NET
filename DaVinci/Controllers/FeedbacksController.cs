using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using System.Collections.Generic;

namespace DaVinci.Utils
{
    public class OnnxModelService
    {
        private readonly InferenceSession _session;

        public OnnxModelService()
        {
            _session = new InferenceSession("MLModel/modelo_analise_sentimento.onnx");
        }

        public string AnalisarSentimento(string texto)
        {
            var input = new DenseTensor<string>(new[] { 1, 1 });
            input[0, 0] = texto;

            var inputs = new List<NamedOnnxValue>
            {
                NamedOnnxValue.CreateFromTensor("input", input)
            };

            using var resultados = _session.Run(inputs);
            var output = resultados.First().AsEnumerable<float>().ToArray();

            return output[0] > 0.5 ? "Positivo" : "Negativo";
        }
    }
}
