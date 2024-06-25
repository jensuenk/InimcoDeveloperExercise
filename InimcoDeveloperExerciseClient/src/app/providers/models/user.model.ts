
export interface UserProfile {
    firstName: string;
    lastName: string;
    socialSkills: string[];
    socialAccounts: { type: string; address: string }[];
}

export interface UserProfileResponse {
    vowels: number;
    consonants: number;
    fullName: string;
    reversedFullName: string;
}