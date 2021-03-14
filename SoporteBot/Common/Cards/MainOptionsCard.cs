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
    public class MainOptionsCard
    {
        public static async Task ToShow(DialogContext stepContext, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync(activity: CreateCarousel(), cancellationToken);
        }

        private static Activity CreateCarousel()
        {
            var preguntasfrecuentes = new HeroCard
            {
                Title = "Preguntas frecuentes del aula virtual PUCESE",
                Images = new List<CardImage> { new CardImage("https://tesisstorage.blob.core.windows.net/images/Preguntas%20frecuentes.png") },
                Buttons = new List<CardAction>()
                {
                    new CardAction(){Title = "¿Cómo puedo encontrar los cursos de mi carrera? 💻", Value = "no puedo encontrar un curso", Type=ActionTypes.ImBack},
                    new CardAction(){Title = "¿Cómo me matriculo a un curso? 💻", Value = "matricularme a un curso", Type=ActionTypes.ImBack},
                    new CardAction(){Title = "¿Qué hago si me aparece error de contraseña? 😵", Value = "olvidé mi contraseña", Type=ActionTypes.ImBack},
                    new CardAction(){Title = "¿Cuál es el tamaño permitido de mi archivo de tarea?", Value = "tamaño máximo de mi tarea", Type=ActionTypes.ImBack},
                    new CardAction(){Title = "¿Cómo puedo ver mis calificaciones en el aula virtual? 💻", Value = "ver calificaciones", Type=ActionTypes.ImBack},
                    new CardAction(){Title = "¿Cómo puedo editar mi perfil del aula virtual? 💻", Value = "editar perfil", Type=ActionTypes.ImBack},
                    new CardAction(){Title = "¿Cómo puede utilizar el app Moodle? 💻", Value = "ver video Moodle app", Type=ActionTypes.ImBack}

                }
            };
            var cardInformacionContacto = new HeroCard
            {
                Title = "Información Contacto",
                Subtitle = "Opciones",
                Images = new List<CardImage> { new CardImage("https://tesisstorage.blob.core.windows.net/images/campus%20pucese.jpg") },
                Buttons = new List<CardAction>()
                {
                    new CardAction(){Title = "Centro de contacto", Value = "Centro de contacto", Type=ActionTypes.ImBack},
                    new CardAction(){Title = "Sitio web", Value = "https://www.pucese.edu.ec/", Type=ActionTypes.OpenUrl}
                }
            };
            var cardCalificacion = new HeroCard
            {
                Title = "Calificación",
                Subtitle = "Opciones",
                Images = new List<CardImage> { new CardImage("https://tesisstorage.blob.core.windows.net/images/califacacion-empresas-noticias-infocif.jpg") },
                Buttons = new List<CardAction>()
                {
                    new CardAction(){Title = "Calificar Bot", Value = "Calificar Bot", Type=ActionTypes.ImBack},

                }
            };

            var videocard = new VideoCard
            {
                Title = "Instalar moodle móvil",
                Media = new List<MediaUrl>
                {
                    new MediaUrl()
                    {
                        Url = "https://tesisstorage.blob.core.windows.net/video/Como%20instalar%20moodle%20m%C3%B3vil.mp4",
                    },
                }
            };

            var gifcard = new AnimationCard
            {
                Title = "Imagen gif",
                Media = new List<MediaUrl>
                {
                    new MediaUrl()
                    {
                        Url="https://tesisstorage.blob.core.windows.net/images/botimagen.gif"
                    }
                }

            };

            var documento = new HeroCard
            {
                Title = "Documento",
                Buttons = new List<CardAction>()
                {
                    new CardAction(){Title="Descargar pdf", Value = "https://tesisstorage.blob.core.windows.net/images/CERTIFICADO%20BOT%20FRAMEWORK.pdf", Type=ActionTypes.OpenUrl} },
            };


            var optionAttachments = new List<Attachment>()
            {
                preguntasfrecuentes.ToAttachment()
                //videocard.ToAttachment()
                //cardInformacionContacto.ToAttachment(),
                //cardCalificacion.ToAttachment(),
            };

            var reply = MessageFactory.Attachment(optionAttachments);
            reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            return reply as Activity;
        }
    }
}
