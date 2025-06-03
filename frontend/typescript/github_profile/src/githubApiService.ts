export interface GitHubUserProfile {
   login: string;
   id: number;
   avatar_url: string;
   html_url: string;
   name: string | null;
   bio: string | null;
   public_repos: number;
   followers: number;
   following: number;
   created_at: string;
}

const GITHUB_API_URL = 'https://api.github.com/users/';

export async function fetchGitHubUserProfile(username: string): Promise<GitHubUserProfile> {
   if (!username) {
      throw new Error('Username is required');
   }

   const trimmedUsername = username.trim();

   const response = await fetch(`${GITHUB_API_URL}${encodeURIComponent(trimmedUsername)}`);

   if (!response.ok) {
      throw new Error('Failed to fetch user profile');
   }

   const data: GitHubUserProfile = await response.json();
   
   return data;
}
