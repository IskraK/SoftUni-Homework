const url = 'http://localhost:3030/jsonstore/advanced/table';

export async function getTableData() {
    const res = await fetch(url);

    if (!res.ok) {
        throw new Error(res.statusText);
    }

    const data = await res.json();
    return data;
}