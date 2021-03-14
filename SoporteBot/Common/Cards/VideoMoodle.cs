using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SoporteBot.Common.Cards
{
    public class VideoMoodle
    {
        public static async Task ToShow(DialogContext stepContext, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync(activity: CreateCarousel(), cancellationToken);
        }


        private static Activity CreateCarousel()
        {
            

            var Ingreso = new HeroCard
            {
                Title = "Descargar e instalar moodle para teléfono",
                Buttons = new List<CardAction>()
                {
                    new CardAction(){Title="PLAY VIDEO", Value = "https://tesisstorage.blob.core.windows.net/video/App2.mp4", Type=ActionTypes.OpenUrl} },
            };

            var optionAttachments = new List<Attachment>()
            {
                Ingreso.ToAttachment()
                //videocard.ToAttachment()

            };

            var reply = MessageFactory.Attachment(optionAttachments);
            reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            return reply as Activity;
        
    }

    }
}
