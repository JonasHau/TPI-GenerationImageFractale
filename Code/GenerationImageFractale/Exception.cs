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
    /// The parent of exception related to invalid boundaries
    /// </summary>
    public class InvalidBoundaryException : Exception
    {
        public InvalidBoundaryException(string message) : base(message)
        {
        }
    }

    /// <summary>
    /// Thrown when 'x min' is invalid
    /// </summary>
    public class InvalidXMinException : InvalidBoundaryException
    {
        public InvalidXMinException() : base("La valeur 'x min' n'a pas été correctement configurée")
        {
        }
    }

    /// <summary>
    /// Thrown when 'x max' is invalid
    /// </summary>
    public class InvalidXMaxException : InvalidBoundaryException
    {
        public InvalidXMaxException() : base("La valeur 'x max' n'a pas été correctement configurée")
        {
        }
    }

    /// <summary>
    /// Thrown when 'y min' is invalid
    /// </summary>
    public class InvalidYMinException : InvalidBoundaryException
    {
        public InvalidYMinException() : base("La valeur 'y min' n'a pas été correctement configurée")
        {
        }
    }

    /// <summary>
    /// Thrown when 'y max' is invalid
    /// </summary>
    public class InvalidYMaxException : InvalidBoundaryException
    {
        public InvalidYMaxException() : base("La valeur 'y max' n'a pas été correctement configurée")
        {
        }
    }
}
