<template>
    <div class="person-component">
        <h1>Persons</h1>

        <div v-if="loading" class="loading">
            Loading... Please refresh later
        </div>

        <div v-if="persons" class="content">
            <table>
                <thead>
                    <tr>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>Phone Number</th>
                        <th>Email</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="p in persons" :key="p.id">
                        <td>{{ p.firstName }}</td>
                        <td>{{ p.lastName }}</td>
                        <td>{{ p.phoneNumber }}</td>
                        <td>{{ p.email }}</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>

<script lang="js">
    import { defineComponent } from 'vue';

    export default defineComponent({
        data() {
            return {
                loading: false,
                persons: null
            };
        },
        created() {
            // fetch the data when the view is created and the data is
            // already being observed
            this.fetchData();
        },
        watch: {
            // call again the method if the route changes
            '$route': 'fetchData'
        },
        methods: {
            fetchData() {
                this.persons = null;
                this.loading = true;

                fetch('person')
                    .then(r => r.json())
                    .then(json => {
                        this.persons = json;
                        this.loading = false;
                        return;
                    });
            }
        },
    });
</script>

<style scoped>
table {
    color: black
}

th {
    font-weight: bold;
}
tr:nth-child(even) {
    background: #F2F2F2;
}

tr:nth-child(odd) {
    background: #FFF;
}

th, td {
    padding-left: .5rem;
    padding-right: .5rem;
}

.person-component {
    text-align: center;
}

tr td {
    text-align: left
}

table {
    margin-left: auto;
    margin-right: auto;
}
</style>