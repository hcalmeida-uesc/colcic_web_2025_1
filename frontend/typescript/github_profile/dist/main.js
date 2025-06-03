// src/main.ts
import { fetchGitHubUserProfile } from './githubApiService.js';
import { displayProfileData, displayErrorMessage, showLoading, hideLoading, clearUI } from './uiManager.js';
// Referências aos elementos de interação
const usernameInputElement = document.getElementById('usernameInput');
const searchButtonElement = document.getElementById('searchButton');
/**
 * Manipula o evento de busca de perfil.
 */
async function handleSearchProfile() {
    const username = usernameInputElement.value;
    clearUI(); // Limpa a UI de buscas anteriores
    showLoading(); // Mostra o indicador de "carregando"
    searchButtonElement.disabled = true; // Desabilita o botão durante a busca
    try {
        const userProfile = await fetchGitHubUserProfile(username);
        displayProfileData(userProfile);
    }
    catch (error) {
        if (error instanceof Error) {
            displayErrorMessage(error.message);
        }
        else {
            displayErrorMessage("Ocorreu um erro desconhecido durante a busca.");
        }
    }
    finally {
        hideLoading(); // Esconde o indicador de "carregando" ao final (sucesso ou erro)
        searchButtonElement.disabled = false; // Reabilita o botão
        usernameInputElement.focus(); // Devolve o foco ao input
    }
}
// Adiciona o listener ao botão de busca
searchButtonElement.addEventListener('click', handleSearchProfile);
// Opcional: permitir busca ao pressionar "Enter" no campo de input
usernameInputElement.addEventListener('keypress', (event) => {
    if (event.key === 'Enter') {
        event.preventDefault(); // Evita o comportamento padrão do Enter (se houver form)
        handleSearchProfile();
    }
});
// Limpa a UI ao carregar a página para um estado inicial limpo
clearUI();
