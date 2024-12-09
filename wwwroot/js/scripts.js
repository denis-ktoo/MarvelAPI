// Javascript file for Index
// Function to fetch entity based on a specified endpoint
async function fetchEntityDirect(endpoint) {
    try {
        const response = await fetch(`https://localhost:7119/api/${endpoint}`);
        if (!response.ok) {
            throw new Error('Entity not found');
        }
        const entity = await response.json();

        // Display full entity details as formatted JSON
        document.getElementById('entityDetails').innerHTML = `<pre>${JSON.stringify(entity, null, 2)}</pre>`;
    } catch (error) {
        document.getElementById('entityDetails').innerHTML = `<p style="color:red;">${error.message}</p>`;
    }
}

// Function to fetch entity details using the input field value
async function fetchEntity() {
    const entityPath = document.getElementById('entityPath').value;
    if (!entityPath) {
        alert('Please enter an entity path.');
        return;
    }

    // Use fetchEntityDirect logic for requests
    await fetchEntityDirect(entityPath);
}