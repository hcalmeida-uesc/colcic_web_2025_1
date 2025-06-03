import { GitHubUserProfile } from "./githubApiService.js";

// Referências aos elementos do DOM que serão manipulados
const profileOutputDiv = document.getElementById('profileOutput') as HTMLDivElement;
const errorDisplayDiv = document.getElementById('errorDisplay') as HTMLDivElement;
const loadingIndicatorDiv = document.getElementById('loadingIndicator') as HTMLDivElement;

/** Mostra o indicador de carregamento e esconde outras seções. */
export function showLoading(): void {
    loadingIndicatorDiv.style.display = 'block';
    profileOutputDiv.style.display = 'none';
    errorDisplayDiv.style.display = 'none';
}

/** Esconde o indicador de carregamento. */
export function hideLoading(): void {
    loadingIndicatorDiv.style.display = 'none';
}

/**
 * Exibe os dados do perfil do usuário no HTML.
 * @param userProfile O objeto contendo os dados do perfil do usuário.
 */
export function displayProfileData(userProfile: GitHubUserProfile): void {
    hideLoading();
    errorDisplayDiv.style.display = 'none'; // Garante que erros anteriores sejam ocultados
    profileOutputDiv.style.display = 'block'; // Mostra o card do perfil

    profileOutputDiv.innerHTML = `
        <img src="${userProfile.avatar_url}" alt="Avatar de ${userProfile.login}">
        <h2>${userProfile.name || userProfile.login} (${userProfile.login})</h2>
        ${userProfile.bio ? `<p><strong>Bio:</strong> ${userProfile.bio}</p>` : ''}
        <p><strong>Repositórios Públicos:</strong> ${userProfile.public_repos}</p>
        <p><strong>Seguidores:</strong> ${userProfile.followers} | <strong>Seguindo:</strong> ${userProfile.following}</p>
        <p><strong>Membro desde:</strong> ${new Date(userProfile.created_at).toLocaleDateString('pt-BR', { day: '2-digit', month: 'long', year: 'numeric' })}</p>
        <p><a href="${userProfile.html_url}" target="_blank" rel="noopener noreferrer">Ver Perfil Completo no GitHub ↗</a></p>
    `;
}

/**
 * Exibe uma mensagem de erro no HTML.
 * @param message A mensagem de erro a ser exibida.
 */
export function displayErrorMessage(message: string): void {
    hideLoading();
    profileOutputDiv.style.display = 'none'; // Garante que o perfil anterior seja ocultado
    errorDisplayDiv.textContent = message;
    errorDisplayDiv.style.display = 'block';
}

/** Limpa qualquer dado de perfil ou mensagem de erro exibida. */
export function clearUI(): void {
    hideLoading();
    profileOutputDiv.innerHTML = '';
    profileOutputDiv.style.display = 'none';
    errorDisplayDiv.textContent = '';
    errorDisplayDiv.style.display = 'none';
}
