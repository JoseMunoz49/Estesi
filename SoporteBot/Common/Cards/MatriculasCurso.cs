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
    public class MatriculasCurso
    {
        public static async Task ToShow(DialogContext stepContext, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync(activity: CreateCarousel(), cancellationToken);
        }
        private static Activity CreateCarousel()
        {
            /*var Ingreso = new SigninCard
            {
                Text = "PASO 1: Ingresa al portal",
                Buttons = new List<CardAction> { new CardAction(ActionTypes.Signin, "Presiona aquí para ingresar al portal", value: "https://aulavirtual.pucese.edu.ec/") },
            };*/

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
            var inicio = new HeroCard
            {
                Title = "PASO 4",
                Subtitle = "A tu lado izquierdo selecciona <b>Inicio del sitio</b>",
                Images = new List<CardImage> { new CardImage("https://tesisstorage.blob.core.windows.net/images/Iniciositio.png") }
            
            };

            var iniciositio = new HeroCard
            {
                Title = "PASO 5",
                Subtitle = "Busca la carrera que estás cursando y elige el nivel en el que te encuentras. Se mostratarán los cursos de ese nivel.",
                Images = new List<CardImage> { new CardImage("https://tesisstorage.blob.core.windows.net/images/seleccion.png") }
            };

            var matricula = new HeroCard
            {
                Title = "PASO 6",
                Subtitle = "Selecciona el curso a matricularte, una vez dentro presiona <b>Auto matricularse</b>, esta opción te matriculará al curso inmediatamente.",
                Images = new List<CardImage> { new CardImage("https://tesisstorage.blob.core.windows.net/images/matricula.png") }

            };

            var nota = new HeroCard
            {
                Subtitle = "❌ Nota: Si el curso tiene clave 🔐, el tutor de la materia deberá proporcionarles la clave del curso o él mismo matricularlos.",          
            };

            var optionAttachments = new List<Attachment>()
            {
                Ingreso.ToAttachment(),
                usuario.ToAttachment(),
                contra.ToAttachment(),
                inicio.ToAttachment(),
                iniciositio.ToAttachment(),
                matricula.ToAttachment(),
                nota.ToAttachment()
                
            };

            var reply = MessageFactory.Attachment(optionAttachments);
            reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            return reply as Activity;
        }
    }
}
