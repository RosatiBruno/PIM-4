using System.Drawing;
using System.Windows.Forms;

namespace TelaPimExercicio
{
    public class Centralizador2
    {
        private Form form;

        public Centralizador2(Form form)
        {
            this.form = form;
        }

        public void CentralizarEmDuasLinhas(Button[] linhaSuperior, Button[] linhaInferior)
        {
            int margemVertical = 10; //Margem fixa entre as linhas
            int alturaTotal = linhaSuperior[0].Height + linhaInferior[0].Height + margemVertical; //Altura total ocupada pelas linhas

            //Calcula a posição Y para centralizar as linhas
            int posicaoYSuperior = (form.ClientSize.Height - alturaTotal) / 2;
            int posicaoYInferior = posicaoYSuperior + linhaSuperior[0].Height + margemVertical;

            Centralizar(linhaSuperior, posicaoYSuperior); //Posição para a linha superior
            Centralizar(linhaInferior, posicaoYInferior); //Posição para a linha inferior
        }

        private void Centralizar(Button[] botoes, int posicaoY)
        {
            int margem = 25; //Margem entre os botões
            int totalBotoes = botoes.Length;
            int larguraTotal = 0;

            //Calcula a largura total dos botões
            foreach (Button botao in botoes)
            {
                larguraTotal += botao.Width;
            }

            //Centraliza os botões na posição Y especificada
            int posicaoX = (form.ClientSize.Width - larguraTotal - (margem * (totalBotoes - 1))) / 2 + 50;

            for (int i = 0; i < totalBotoes; i++)
            {
                botoes[i].Location = new Point(posicaoX, posicaoY); //Usando a posição Y especificada
                posicaoX += botoes[i].Width + margem; //Move a posição X para o próximo botão
            }
        }
    }
}
