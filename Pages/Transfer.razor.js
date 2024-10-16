function getConfig() {
    let starkContractAddress = "0xa3aee8bce55beea1951ef834b99f3ac60d1abeeb";
    let tokenAddress = "0xac98d8d1bb27a94e79fbf49198210240688bb1ed";
    let publicApiUrl = "https://api.x.immutable.com/v1";
    let linkFrameUrl = "https://link.x.immutable.com";
    let isSandbox = false;

    if (location.href.includes('?beta=true')) {
        starkContractAddress = "0x2d5c349fd8464da06a3f90b4b0e9195f3d1b7f98";
        tokenAddress = "0xbabb5c8cf3b679e855e96ba77942cc3a184396a5";
        publicApiUrl = "https://api.sandbox.x.immutable.com/v1";
        linkFrameUrl = "https://link.sandbox.x.immutable.com";
        isSandbox = true;
    }

    return {
        starkContractAddress,
        tokenAddress,
        publicApiUrl,
        linkFrameUrl,
        isSandbox
    };
}

export async function init(walletAddress) {
    const client = await getClient();

    const assets = await client.getAssets({
        user: walletAddress,
        page_size: 200,
        order_by: "desc"
    });

    return assets.result;
}

export async function transfer(assetIds, toAddress) {
    const client = await getLink();
    const config = getConfig();

    const payload = assetIds.map(assetId => {
        return {
            type: imx.ERC721TokenType.ERC721, // Must be of type ERC721
            tokenId: assetId, // the token ID
            tokenAddress: config.tokenAddress, // the collection address / contract address this token belongs to
            toAddress: toAddress // the wallet address this token is being transferred to
        };
    });

    const assets = await client.batchNftTransfer(payload);
    return assets;
}

export async function getClient() {

    const config = getConfig();

    return await imx.ImmutableXClient.build({
        publicApiUrl: config.publicApiUrl,
        starkContractAddress: config.starkContractAddress
    });
}

export function getLink() {

    const config = getConfig();

    return new imx.Link(config.linkFrameUrl);
}

export function setup() {
    const sdk = getLink();
    sdk.setup({});
}
