using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;
using Microsoft.Bot.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SoporteBot.Common.Cards
{
    public class SegundaRespuesta :ComponentDialog
    {
        public SegundaRespuesta()
        {
            var waterfallStep = new WaterfallStep[]
            {
                Confirmation,

            };
            AddDialog(new WaterfallDialog(nameof(WaterfallDialog), waterfallStep));
            AddDialog(new TextPrompt(nameof(TextPrompt)));
        }

        public static async Task ToShow(DialogContext stepContext, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync(activity: CreateButtonConfirmation(), cancellationToken);
        }

        private async Task<DialogTurnResult> Confirmation(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var options = await stepContext.PromptAsync(
                nameof(ConfirmPrompt),
                new PromptOptions
                {
                    Prompt = CreateButtonConfirmation(),
                    Style = ListStyle.HeroCard

                }, cancellationToken
                );
            return options;
        }
        private static Activity CreateButtonConfirmation()
        {
            var reply = MessageFactory.Text("¿Te he sido de ayuda?");
            var confirmacion = new HeroCard
            {
                Text = "<b>¿Tienes alguna otra pregunta?</b>",
                Buttons = new List<CardAction>()
                {
                    new CardAction(){Title = "Si", Value= " si por favor", Type=ActionTypes.ImBack},
                    new CardAction(){Title = "No", Value= "no gracias", Type=ActionTypes.ImBack}
                }
            };
            var optionAttachments = new List<Attachment>()
            {
                confirmacion.ToAttachment()
            };

            var reply2 = MessageFactory.Attachment(optionAttachments);
            reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;

            return reply2 as Activity;

        }
    }
}
