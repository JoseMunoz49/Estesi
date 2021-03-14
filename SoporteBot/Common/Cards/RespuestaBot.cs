using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SoporteBot.Dialogs.Qualification;
using Microsoft.Bot.Builder.Dialogs.Choices;

namespace SoporteBot.Common.Cards
{
    public class RespuestaBot: ComponentDialog
    {
        public RespuestaBot()
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
                    Style=ListStyle.HeroCard

                }, cancellationToken
                );
            return options;
        }

        private static Activity CreateButtonConfirmation()
        {
            var reply = MessageFactory.Text("¿Te he sido de ayuda?");
            var confirmacion = new HeroCard  
            {
                 Text="<b>¿Te he sido de ayuda?</b>",
                 Buttons = new List<CardAction>()
                {
                    new CardAction(){Title = "Si", Value= "1", Type=ActionTypes.PostBack},
                    new CardAction(){Title = "No", Value= "0", Type=ActionTypes.PostBack}
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
