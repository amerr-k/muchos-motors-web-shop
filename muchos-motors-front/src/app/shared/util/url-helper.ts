export function createUrl(...parts: string[]) {
  return parts
    .map((part) => part.trim())
    .filter((part) => part !== '')
    .join('/');
}
