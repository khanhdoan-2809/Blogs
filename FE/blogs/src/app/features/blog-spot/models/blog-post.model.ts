export interface BlogPost {
    id: string
    title: string
    shortDescription: string
    content: string
    featuredImageUrl: string
    urlHandle: string
    author: string
    publishDate: Date
    isVisible: boolean
}