using System;
using System.Collections.Generic;
using System.Text;

namespace CodingLibrary.ChallangeFive
{
    public class Response
    {
        public Response()
        {
            Messages = new List<string>();
        }
        /// <summary>
        /// Gets or sets wether the request was successfull
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the messages coming back from the server
        /// </summary>
        public List<String> Messages { get; set; }
    }
}
