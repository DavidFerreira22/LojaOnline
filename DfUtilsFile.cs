using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.IO;
//using iTextSharp.text;
//using iTextSharp.text.pdf;
//using iTextSharp.text.html.simpleparser;
using System.Configuration;
using System.Security.Cryptography;

namespace Df
{
    public class utils
    {
        // Enciptação_formador
        public static string EncryptString(string Message)
        {
            string enc = "";
            return enc;
        }

        // Desencriptação_formador
        public static string DecryptString(string Message)
        {
            string Results = "";
            return Results;



        }

        // Validador de Pass_aula
        public static bool Validar(string situacao)
        {

            Regex maiusculas = new Regex("[A-Z]");
            Regex minusculas = new Regex("[a-z]");
            Regex digitos = new Regex("[0-9]");
            Regex especiais = new Regex("[^a-zA-Z0-9]");
            Regex plica = new Regex("[']");


            if (situacao.Length < 6)
            {
                return false;
            }
            if (maiusculas.Matches(situacao).Count == 0)
            {
                return false;
            }
            if (minusculas.Matches(situacao).Count == 0)
            {
                return false;
            }
            if (digitos.Matches(situacao).Count == 0)
            {
                return false;
            }
            if (especiais.Matches(situacao).Count == 0)
            {
                return false;
            }
            if (plica.Matches(situacao).Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // Binary Search
        public static int BinarySearch(int[] arr, int target)
        {
            int left = 0;
            int right = arr.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (arr[mid] == target)
                    return mid;
                else if (arr[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return -1; // Target not found
        }

        // Bubble Sort
        public static void BubbleSort(int[] array)
        {
            int n = array.Length;
            bool swapped;

            for (int i = 0; i < n - 1; i++)
            {
                swapped = false;

                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        // Swap elements
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;

                        swapped = true;
                    }
                }

                // If no two elements were swapped in the inner loop, the array is already sorted
                if (!swapped)
                {
                    break;
                }
            }
        }


    }
}