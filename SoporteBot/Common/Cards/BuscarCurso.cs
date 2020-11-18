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
    public class BuscarCurso
    {
        public static async Task ToShow(DialogContext stepContext, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync(activity: CreateCarousel(), cancellationToken);
        }
        private static Activity CreateCarousel()
        {
            var Ingreso = new HeroCard
            {
                Subtitle = "PASO 1",
                Text = "Ingresa a https://aulavirtual.pucese.edu.ec/ y accede a la plataforma",
                Images = new List<CardImage> { new CardImage("https://clinicbotstorage12.blob.core.windows.net/images/ingreso.png") }

            };
            var usuario = new HeroCard
            {
                Subtitle = "PASO 2",
                Text = "Ingresa tu correo institucional",

                Images = new List<CardImage> {
                    new CardImage("https://clinicbotstorage12.blob.core.windows.net/images/crede1.png")
                     }

            };

            var contra = new HeroCard
            {
                Subtitle = "PASO 3",
                Text = "Ingresa tu contraseña del correo institucional",

                Images = new List<CardImage> {
                    new CardImage("https://clinicbotstorage12.blob.core.windows.net/images/crede2.png")
                     }


            };
            var inicio = new HeroCard
            {
                Subtitle = "PASO 4",
                Text = "A tu lado izquierdo selecciona 'Inicio del sitio'",
                Images = new List<CardImage> { new CardImage("https://clinicbotstorage12.blob.core.windows.net/images/Iniciositio.png") }

            };

            var iniciositio = new HeroCard
            {
                Subtitle = "PASO 5",
                Text = "Busca la carrera que estás cursando y elige el nivel en el que te encuentras. Al realizar esto se mostrarán todos los cursos de ese nivel.",
                Images = new List<CardImage> { new CardImage("https://clinicbotstorage12.blob.core.windows.net/images/seleccion.png") }

            };
            var seleccion = new HeroCard
            {
                Subtitle = "PASO 6",
                Text = "Una vez estes dentro, podrás utilizar el buscador de cursos que el sistema proporciona.",
                Images = new List<CardImage> { new CardImage("https://clinicbotstorage12.blob.core.windows.net/images/buscador2.png") }

            };


            var optionAttachments = new List<Attachment>()
            {
                Ingreso.ToAttachment(),
                usuario.ToAttachment(),
                contra.ToAttachment(),
                inicio.ToAttachment(),
                iniciositio.ToAttachment(),
                seleccion.ToAttachment()
                

            };

            var reply = MessageFactory.Attachment(optionAttachments);
            reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            return reply as Activity;
        }
    }
}
