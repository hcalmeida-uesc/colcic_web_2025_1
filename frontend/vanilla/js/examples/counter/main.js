/**
 * Módulo principal para manipulação do contador na interface.
 * 
 * Importa as funções `incrementar` e `decrementar` do módulo 'counter.js' e
 * atualiza o valor exibido na página conforme o usuário clica nos botões de incremento e decremento.
 * 
 * Elementos DOM:
 * - 'valor': Elemento <p> que exibe o valor atual do contador.
 * - 'mais': Botão para incrementar o valor do contador.
 * - 'menos': Botão para decrementar o valor do contador.
 * 
 * Eventos:
 * - Ao clicar em 'mais', o valor do contador é incrementado e atualizado na tela.
 * - Ao clicar em 'menos', o valor do contador é decrementado e atualizado na tela.
 */
import { incrementar, decrementar } from './counter.js';

const p = document.getElementById('valor');

document.getElementById('mais').addEventListener('click', () => {
  p.textContent = incrementar();
});

document.getElementById('menos').addEventListener('click', () => {
  p.textContent = decrementar();
});
