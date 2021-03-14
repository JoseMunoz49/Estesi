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
    public class VerCalificaciones
    {
        public static async Task ToShow(DialogContext stepContext, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync(activity: CreateCarousel(), cancellationToken);
        }
        private static Activity CreateCarousel()
        {

            var Ingreso = new HeroCard
            {
                Title = "PASO 1",
                Subtitle = "Haga click en el siguiente enlace para redireccionar a la plataforma e ingrese <a href='https://aulavirtual.pucese.edu.ec/'>Página principal Aula Virtual</a>",
                Images = new List<CardImage> { new CardImage("https://tesisstorage.blob.core.windows.net/images/ingreso.png") },

            };

            var usuario = new HeroCard
            {
                Title = "PASO 2",
                Subtitle = "Ingresa tu correo institucional",

                Images = new List<CardImage> {
                    new CardImage("https://tesisstorage.blob.core.windows.net/images/crede1.png")
                     }

            };

            var contra = new HeroCard
            {
                Title = "PASO 3",
                Subtitle = "Ingresa tu contraseña del correo institucional",

                Images = new List<CardImage> {
                    new CardImage("https://tesisstorage.blob.core.windows.net/images/crede2.png")
                     }


            };
            var califi1 = new HeroCard
            {
                Title = "PASO 4",
                Subtitle = "En tu lado superior derecho, alado de su imagen presione en la flecha y seleccione <b>calificaciones</b>.",
                Images = new List<CardImage> { new CardImage("https://tesisstorage.blob.core.windows.net/images/cali1.png") }

            };

            var califi2 = new HeroCard
            {
                Title = "PASO 5",
                Subtitle = "Una vez dentro, podrá ver las calificaciones de las materias en el que esté matriculad@.",
                Images = new List<CardImage> { new CardImage("https://tesisstorage.blob.core.windows.net/images/cali4.png") }

            };
            var califi3 = new HeroCard
            {
                Title = "PASO 6",
                Subtitle = "Si selecciona una materia en específico, podrá ver un registro más detallado de sus calificaciones.",
                Images = new List<CardImage> { new CardImage("https://tesisstorage.blob.core.windows.net/images/cali3.png") }

            };


            var optionAttachments = new List<Attachment>()
            {
                Ingreso.ToAttachment(),
                usuario.ToAttachment(),
                contra.ToAttachment(),
                califi1.ToAttachment(),
                califi2.ToAttachment(),
                califi3.ToAttachment()


            };

            var reply = MessageFactory.Attachment(optionAttachments);
            reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            return reply as Activity;
        }
    }
}
