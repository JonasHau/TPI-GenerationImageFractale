using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerationImageFractale
{
    /// <summary>
    /// Thrown when the fractal selected doesn't exist
    /// </summary>
    public class InvalidFractalException : Exception
    {
        public InvalidFractalException() : base("La fractale sélectionnée n'existe pas. Veuillez choisir parmi 'Mandelbrot' et 'Julia'.")
        {
        }
    }

    /// <summary>
    /// The parent of exception related to invalid parameters
    /// </summary>
    public class InvalidParameterException : Exception
    {
        public InvalidParameterException(string message) : base(message)
        {
        }
    }

    /// <summary>
    /// Thrown when 'x min' is invalid
    /// </summary>
    public class InvalidXMinException : InvalidParameterException
    {
        public InvalidXMinException() : base("La valeur 'x min' n'a pas été correctement configurée")
        {
        }
    }

    /// <summary>
    /// Thrown when 'x max' is invalid
    /// </summary>
    public class InvalidXMaxException : InvalidParameterException
    {
        public InvalidXMaxException() : base("La valeur 'x max' n'a pas été correctement configurée")
        {
        }
    }

    /// <summary>
    /// Thrown when 'y min' is invalid
    /// </summary>
    public class InvalidYMinException : InvalidParameterException
    {
        public InvalidYMinException() : base("La valeur 'y min' n'a pas été correctement configurée")
        {
        }
    }

    /// <summary>
    /// Thrown when 'y max' is invalid
    /// </summary>
    public class InvalidYMaxException : InvalidParameterException
    {
        public InvalidYMaxException() : base("La valeur 'y max' n'a pas été correctement configurée")
        {
        }
    }

    /// <summary>
    /// Thrown when 'c real' is invalid
    /// </summary>
    public class InvalidCRealException : InvalidParameterException
    {
        public InvalidCRealException() : base("La valeur 'c réel' n'a pas été correctement configurée")
        {
        }
    }

    /// <summary>
    /// Thrown when 'c imaginary' is invalid
    /// </summary>
    public class InvalidCImaginaryException : InvalidParameterException
    {
        public InvalidCImaginaryException() : base("La valeur 'c imaginaire' n'a pas été correctement configurée")
        {
        }
    }
}
