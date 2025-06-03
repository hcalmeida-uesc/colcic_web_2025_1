const GITHUB_API_URL = 'https://api.github.com/users/';
export async function fetchGitHubUserProfile(username) {
    if (!username) {
        throw new Error('Username is required');
    }
    const trimmedUsername = username.trim();
    const response = await fetch(`${GITHUB_API_URL}${encodeURIComponent(trimmedUsername)}`);
    if (!response.ok) {
        throw new Error('Failed to fetch user profile');
    }
    const data = await response.json();
    return data;
}
