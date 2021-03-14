using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using SoporteBot.Common.Cards;
using SoporteBot.Data;
using SoporteBot.Dialogs.Qualification;
using SoporteBot.Infrastructure.Luis;
using SoporteBot.Infrastructure.QnAMakerAI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SoporteBot.Dialogs
{
    public class RootDialog: ComponentDialog
    {
        private readonly ILuisService _luisService;
        private readonly IDataBaseService _databaseService;
        private readonly IQnAMakerAIService _qnAMakerAIService;
        public RootDialog(ILuisService luisService, IDataBaseService databaseService, IQnAMakerAIService qnAMakerAIService)
        {
            _qnAMakerAIService = qnAMakerAIService;
            _databaseService = databaseService;
            _luisService = luisService;
            var waterfallSteps = new WaterfallStep[]
            {

                InitialProcess,
                FinalProcess
            };
            AddDialog(new QualificationDialog(_databaseService));
            AddDialog(new TextPrompt(nameof(TextPrompt)));
            AddDialog(new WaterfallDialog(nameof(WaterfallDialog), waterfallSteps));
            InitialDialogId = nameof(WaterfallDialog);
        }

        private async Task<DialogTurnResult> InitialProcess(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var luisResult = await _luisService._luisRecognizer.RecognizeAsync(stepContext.Context, cancellationToken);
            return await ManageIntentions(stepContext, luisResult, cancellationToken);
        }

        private async Task<DialogTurnResult> ManageIntentions(WaterfallStepContext stepContext, Microsoft.Bot.Builder.RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            var TopIntent = luisResult.GetTopScoringIntent();
            switch (TopIntent.intent)
            {
                case "Saludar":
                    await IntentSaludar(stepContext, luisResult, cancellationToken);
                    break;
                /*case "Agradecer":
                    await IntentAgradecer(stepContext, luisResult, cancellationToken);
                    break;
                case "Despedir":
                    await IntentDespedir(stepContext, luisResult, cancellationToken);
                    break;*/
                case "Matrículas":
                    await IntentMatriculas(stepContext, luisResult, cancellationToken);
                    break;
                case "Video":
                    await IntentVideo(stepContext, luisResult, cancellationToken);
                    break;
                case "Perfil":
                    await IntentPerfil(stepContext, luisResult, cancellationToken);
                    break;
                case "Calificacciones":
                    await IntentCalificaciones(stepContext, luisResult, cancellationToken);
                    break;
                case "BuscarCurso":
                    await IntentBuscarCurso(stepContext, luisResult, cancellationToken);
                    break;
                case "Confirmacion":
                    await Confirmacion(stepContext, luisResult, cancellationToken);
                    break;
                case "VerOpciones":
                    await IntentVerOpciones(stepContext, luisResult, cancellationToken);
                    break;
                case "VerCentroContacto":
                    await IntentVerCentroContacto(stepContext, luisResult, cancellationToken);
                    break;
                case "Calificar":
                    return await IntentCalificar(stepContext, luisResult, cancellationToken);
                case "None":
                    await IntentNone(stepContext, luisResult, cancellationToken);
                    break;
                default:
                    break;
            }
            return await stepContext.NextAsync(cancellationToken: cancellationToken);
        }

        



        #region IntentLuis
        private async Task IntentVerCentroContacto(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            string phoneDetail = $"Los numeros de atención son los siguientes:{Environment.NewLine}" +
                $"📞 +593 (06) 2721983{ Environment.NewLine} 📞 +593 (06) 2721595";
            string addresDetail = $"🏫 Estamos ubicados en {Environment.NewLine}  Espejo y subida a Santa Cruz";
            await stepContext.Context.SendActivityAsync(phoneDetail, cancellationToken: cancellationToken);
            await Task.Delay(1000);
            await stepContext.Context.SendActivityAsync(addresDetail, cancellationToken: cancellationToken);
            await Task.Delay(1000);
            await stepContext.Context.SendActivityAsync("En qué más te puedo ayudar?", cancellationToken: cancellationToken);
            
        }

        private async Task IntentPerfil(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync($"**Para editar su perfil, porfavor siga los siguientes pasos 📜**", cancellationToken: cancellationToken);
            await Task.Delay(2000);
            await Perfil.ToShow(stepContext, cancellationToken);
            await Task.Delay(5000);
            await RespuestaBot.ToShow(stepContext, cancellationToken);
        }

        private async Task Confirmacion(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await SegundaRespuesta.ToShow(stepContext, cancellationToken);
        }

        private async Task IntentCalificaciones(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync($"**Para ver sus calificaciones 💻 realice los siguientes pasos:**", cancellationToken: cancellationToken);
            await Task.Delay(3000);
            await VerCalificaciones.ToShow(stepContext, cancellationToken);
            await Task.Delay(5000);
            await RespuestaBot.ToShow(stepContext, cancellationToken);
        }

        private async Task IntentVideo(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync($"**Para utilizar el aulavirtual desde el móvil 📳:**", cancellationToken: cancellationToken);
            await Task.Delay(1000);
            await stepContext.Context.SendActivityAsync($"**Por favor mire el siguiente video 😊**", cancellationToken: cancellationToken);
            await Task.Delay(2000);
            await VideoMoodle.ToShow(stepContext, cancellationToken);
            await Task.Delay(5000);
            await RespuestaBot.ToShow(stepContext, cancellationToken);
        }
        private async Task IntentBuscarCurso(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync($"**Para acceder a un curso 📒 realice los siguientes pasos:**", cancellationToken: cancellationToken);
            await Task.Delay(3000);
            await BuscarCurso.ToShow(stepContext, cancellationToken);
            await Task.Delay(5000);
            await RespuestaBot.ToShow(stepContext, cancellationToken);
        }

        private async Task IntentMatriculas(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync($"**Para matricularte a un curso 📜**", cancellationToken: cancellationToken);
            await Task.Delay(2000);
            await MatriculasCurso.ToShow(stepContext, cancellationToken);
            await Task.Delay(5000);
            await RespuestaBot.ToShow(stepContext, cancellationToken);
            
           
        }
        private async Task<DialogTurnResult> IntentCalificar(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("**No te preocupes, espero haberte ayudado 😊**", cancellationToken: cancellationToken);
            await Task.Delay(2000);
            await stepContext.Context.SendActivityAsync("**Podrías ayudarme a mejorar, danos tu opinión calificando tu experiencia por favor ❤**", cancellationToken: cancellationToken);
            await Task.Delay(2000);
            return await stepContext.BeginDialogAsync(nameof(QualificationDialog), cancellationToken: cancellationToken);

        }

        private async Task IntentVerOpciones(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("**Te mostraré como puedo ayudarte** 👌", cancellationToken: cancellationToken);
            await MainOptionsCard.ToShow(stepContext, cancellationToken);
        }

        private async Task IntentSaludar(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync($"**Hola soy Tiny 😀 tu asistente de servicios de TI virtual, ¿en qué puedo ayudarte 😊?**", cancellationToken: cancellationToken);
            await Task.Delay(2000);
            await IntentVerOpciones(stepContext, luisResult, cancellationToken);

        }

        /*private async Task IntentAgradecer(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("No te preocupes, me gusta ayudar 😊", cancellationToken: cancellationToken);

        }

        private async Task IntentDespedir(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync($"Hasta pronto! Ten un excelente día 😊, si necesitas más ayuda ya sabes donde encontrarme 😉", cancellationToken: cancellationToken);
        }*/

        private async Task IntentNone(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            var resultQnA = await _qnAMakerAIService._qnaMakerResult.GetAnswersAsync(stepContext.Context);

            var score = resultQnA.FirstOrDefault()?.Score;
            string response = resultQnA.FirstOrDefault()?.Answer;

            if (score >= 0.5)
            {
                await stepContext.Context.SendActivityAsync(response, cancellationToken: cancellationToken);
                await Task.Delay(5000);
                await RespuestaBot.ToShow(stepContext, cancellationToken);
            }
            else
            {
                await stepContext.Context.SendActivityAsync($"**Lo siento 😟, no pude entenderte 😔**", cancellationToken: cancellationToken);
                await Task.Delay(2000);
                await IntentVerOpciones(stepContext, luisResult, cancellationToken);
            }

            
        }
        #endregion
        private async Task<DialogTurnResult> FinalProcess(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            return await stepContext.EndDialogAsync(cancellationToken: cancellationToken);
        }
    }
}
