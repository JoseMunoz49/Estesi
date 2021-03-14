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
    public class Perfil
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
                Subtitle = "Ingresa tu correo institucional y contraseña",
                
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
                Title = "PASO 3",
                Subtitle = "En tu lado superior derecho, alado de su imagen presione en la flecha y seleccione <b>perfil</b>.",
                Images = new List<CardImage> { new CardImage("https://tesisstorage.blob.core.windows.net/images/perfil2.png") }

            };

            var califi2 = new HeroCard
            {
                Title = "PASO 4",
                Subtitle = "Una vez dentro, alado de su imagen seleccione la ruedita y elija <b>editar perfil</b>",
                Images = new List<CardImage> { new CardImage("https://tesisstorage.blob.core.windows.net/images/perfil11.png") }

            };
            var califi3 = new HeroCard
            {
                Title = "PASO 5",
                Subtitle = "En esta sección, puede cambiar la información",
                Images = new List<CardImage> { new CardImage("https://tesisstorage.blob.core.windows.net/images/perfil12.png") }

            };

            var perfil6 = new HeroCard
            {
                Title = "PASO 6",
                Subtitle = "También puede cambiar la imagen de perfil a su gusto, haciendo click en la hojita 📄",
                Images = new List<CardImage> { new CardImage("https://tesisstorage.blob.core.windows.net/images/perfil6.png") }

            };

            var perfil7 = new HeroCard
            {
                Title = "PASO 7",
                Subtitle = $"De click en <b>seleccionar archivo</b>",
                Images = new List<CardImage> { new CardImage("https://tesisstorage.blob.core.windows.net/images/perfil13.png") }

            };

            var perfill8 = new HeroCard
            {
                Title = "PASO 8",
                Subtitle = "Seleccione la imagen a su gusto y luego de click en <b>abrir</b>",
                Images = new List<CardImage> { new CardImage("https://tesisstorage.blob.core.windows.net/images/finalcharlar.png") }
            };

            var perfil9 = new HeroCard
            {
                Title = "PASO 9",
                Subtitle = "Una vez esté todo listo, de click en <b>subir archivo</b>",
                Images = new List<CardImage> { new CardImage("https://tesisstorage.blob.core.windows.net/images/perfil9.png") }

            };

            var perf10 = new HeroCard
            {
                Title = "PASO 10",
                Subtitle = "Cuando ya este todo listo, de click en <b>actualizar información personal</b> y automáticamente se actualizará su perfil",
                Images = new List<CardImage> { new CardImage("https://tesisstorage.blob.core.windows.net/images/perfil16.png") }

            };


            var optionAttachments = new List<Attachment>()
            {
                Ingreso.ToAttachment(),
                usuario.ToAttachment(),
                //contra.ToAttachment(),
                califi1.ToAttachment(),
                califi2.ToAttachment(),
                califi3.ToAttachment(),
                perfil6.ToAttachment(),
                perfil7.ToAttachment(),
                perfill8.ToAttachment(),
                perfil9.ToAttachment(),
                perf10.ToAttachment()
               
            };

            var reply = MessageFactory.Attachment(optionAttachments);
            reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            return reply as Activity;
        }
    }
}
